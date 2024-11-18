import React from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faInstagram,
  faReact,
  faLinkedinIn,
  faGithub,
} from "@fortawesome/free-brands-svg-icons";
import { Box, Typography, IconButton } from "@mui/material";

const Footer = () => {
  return (
    <Box
      component='footer'
      sx={{
        mt: 4,
        py: 2,
        backgroundColor: "#f5f5f5",
        textAlign: "center",
        borderTop: "1px solid #ddd",
      }}>
      <Typography variant='body2' color='text.secondary' sx={{ mb: 1 }}>
        Copyright © 2024 - Gabriel Abreu
      </Typography>
      <Box
        sx={{
          display: "flex",
          justifyContent: "center",
          gap: 2,
          mt: 1,
        }}>
        <IconButton
          component='a'
          href='https://codewithgabo.com'
          target='_blank'
          rel='noopener noreferrer'
          sx={{ backgroundColor: "white", color: "#1DA1F2" }}>
          <FontAwesomeIcon icon={faReact} />
        </IconButton>
        <IconButton
          component='a'
          href='https://www.instagram.com/codewithgabo/'
          target='_blank'
          rel='noopener noreferrer'
          sx={{ backgroundColor: "white", color: "#E4405F" }}>
          <FontAwesomeIcon icon={faInstagram} />
        </IconButton>
        <IconButton
          component='a'
          href='https://www.linkedin.com/in/francisco-gabriel-abreu-cornelio/'
          target='_blank'
          rel='noopener noreferrer'
          sx={{ backgroundColor: "white", color: "#0077B5" }}>
          <FontAwesomeIcon icon={faLinkedinIn} />
        </IconButton>
        <IconButton
          component='a'
          href='https://github.com/Gabbs27'
          target='_blank'
          rel='noopener noreferrer'
          sx={{ backgroundColor: "white", color: "#333" }}>
          <FontAwesomeIcon icon={faGithub} />
        </IconButton>
      </Box>
    </Box>
  );
};

export default Footer;
