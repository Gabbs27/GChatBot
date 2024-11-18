import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import { ThemeProvider, createTheme } from '@mui/material';
import App from './App';
import { SignalRProvider } from './context/SignalRContext';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

const defaultTheme = createTheme();


root.render(
  <React.StrictMode>
    <ThemeProvider theme={defaultTheme}>
      <SignalRProvider>
        <App />
      </SignalRProvider>
    </ThemeProvider>
  </React.StrictMode>
);

