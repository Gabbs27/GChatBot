import React from "react";
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import TextField from '@mui/material/TextField';
import Link from '@mui/material/Link';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { UserService } from "../services/userServices";
import { SignUpDTO } from "../DTOs/SignUpDTO";
import helpers from "../utils/helpers";
import { useNavigate } from "react-router-dom";
import Snackbar from "@mui/material/Snackbar";
import IconButton from "@mui/material/IconButton";
import Alert from "@mui/material/Alert";
import CloseIcon from '@mui/icons-material/Close';
import CircularProgress from "@mui/material/CircularProgress";

export const SignUp = () => {
    const [isLoading, setIsLoading] = React.useState(false);
    const [isOpen, setIsOpen] = React.useState(false);
    const [error, setError] = React.useState("");
    const navigate = useNavigate();

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        const data = new FormData(event.currentTarget);
        const signUpDto = new SignUpDTO();
        signUpDto.DisplayName = helpers.getValueOrDefault(data, 'username');
        signUpDto.Email = helpers.getValueOrDefault(data, 'email');
        signUpDto.FirstName = helpers.getValueOrDefault(data, 'firstName');
        signUpDto.LastName = helpers.getValueOrDefault(data, 'lastName');
        signUpDto.Password = helpers.getValueOrDefault(data, 'password');
        signUpDto.PasswordConfirm = helpers.getValueOrDefault(data, 'confirmPassword');

        try {
            setIsLoading(true);
            const signUpResult = await UserService.signUp(signUpDto);
            if (signUpResult.success) {
                navigate('/');
            } else {
                setError(signUpResult.errors.join(', '));
                setIsOpen(true);
            }
        } catch (exception) {
            let message = '';
            if (exception instanceof Error) message = exception?.message;
            else if (typeof exception === "string") message = exception;

            setError(`${message} Check that you've correctly set the constants under the utils folder.`);
            setIsOpen(true);
        } finally {
            setIsLoading(false);
        }
    };

    const handleToastClose = () => {
        setIsOpen(false);
    };

    return (
        <Container component="main" maxWidth="xs">
            <CssBaseline />
            <Snackbar
                open={isOpen}
                autoHideDuration={3500}
                onClose={handleToastClose}
                anchorOrigin={{
                    horizontal: 'right',
                    vertical: 'top',
                }}
                action={
                    <IconButton
                        size="small"
                        aria-label="close"
                        color="inherit"
                        onClick={handleToastClose}
                    >
                        <CloseIcon fontSize="small" />
                    </IconButton>
                }
            >
                <Alert severity="error" sx={{ width: '100%' }}>
                    {error}
                </Alert>
            </Snackbar>
            <Box
                sx={{
                    marginTop: 8,
                    display: 'flex',
                    flexDirection: 'column',
                    alignItems: 'center',
                }}
            >
                <Avatar sx={{ m: 1, bgcolor: '#276461' }}>
                    <LockOutlinedIcon />
                </Avatar>
                <Typography component="h1" variant="h5" sx={{ color: '#276461' }}>
                    Sign up
                </Typography>
                <Box component="form" noValidate onSubmit={handleSubmit} sx={{ mt: 3 }}>
                    <Grid container spacing={2}>
                        <Grid item xs={12} sm={6}>
                            <TextField
                                autoComplete="given-name"
                                name="firstName"
                                required
                                fullWidth
                                id="firstName"
                                label="First Name"
                                autoFocus
                                sx={{
                                    '& .MuiInputBase-root': { backgroundColor: '#f6f4f0' },
                                    '& .MuiInputLabel-root': { color: '#276461' },
                                }}
                            />
                        </Grid>
                        <Grid item xs={12} sm={6}>
                            <TextField
                                required
                                fullWidth
                                id="lastName"
                                label="Last Name"
                                name="lastName"
                                autoComplete="family-name"
                                sx={{
                                    '& .MuiInputBase-root': { backgroundColor: '#f6f4f0' },
                                    '& .MuiInputLabel-root': { color: '#276461' },
                                }}
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <TextField
                                required
                                fullWidth
                                id="username"
                                label="Display Name"
                                name="username"
                                autoComplete="username"
                                sx={{
                                    '& .MuiInputBase-root': { backgroundColor: '#f6f4f0' },
                                    '& .MuiInputLabel-root': { color: '#276461' },
                                }}
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <TextField
                                required
                                fullWidth
                                id="email"
                                label="Email Address"
                                name="email"
                                autoComplete="email"
                                sx={{
                                    '& .MuiInputBase-root': { backgroundColor: '#f6f4f0' },
                                    '& .MuiInputLabel-root': { color: '#276461' },
                                }}
                            />
                        </Grid>
                        <Grid item xs={12} sm={6}>
                            <TextField
                                required
                                fullWidth
                                name="password"
                                label="Password"
                                type="password"
                                id="password"
                                autoComplete="new-password"
                                sx={{
                                    '& .MuiInputBase-root': { backgroundColor: '#f6f4f0' },
                                    '& .MuiInputLabel-root': { color: '#276461' },
                                }}
                            />
                        </Grid>
                        <Grid item xs={12} sm={6}>
                            <TextField
                                required
                                fullWidth
                                name="confirmPassword"
                                label="Password Confirm"
                                type="password"
                                id="confirmPassword"
                                autoComplete="new-password"
                                sx={{
                                    '& .MuiInputBase-root': { backgroundColor: '#f6f4f0' },
                                    '& .MuiInputLabel-root': { color: '#276461' },
                                }}
                            />
                        </Grid>
                    </Grid>

                    {!isLoading ? (
                        <Button
                            type="submit"
                            fullWidth
                            variant="contained"
                            sx={{
                                mt: 3,
                                mb: 2,
                                backgroundColor: '#276461',
                                color: '#fbfaf8',
                                '&:hover': { backgroundColor: '#063034' },
                            }}
                        >
                            Sign Up
                        </Button>
                    ) : (
                        <Grid
                            sx={{
                                display: 'flex',
                                width: '100%',
                            }}
                            justifyContent="center"
                            alignItems="center"
                        >
                            <CircularProgress sx={{ color: '#276461' }} />
                        </Grid>
                    )}
                    <Grid container justifyContent="flex-end">
                        <Grid item>
                            <Link
                                href="/"
                                variant="body2"
                                sx={{
                                    color: '#276461',
                                    '&:hover': { color: '#063034' },
                                }}
                            >
                                Already have an account? Sign in
                            </Link>
                        </Grid>
                    </Grid>
                </Box>
            </Box>
        </Container>
    );
};
