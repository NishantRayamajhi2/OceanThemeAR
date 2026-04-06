# PayID QR Scanner App

This project focuses on developing a PayID QR code scanning feature for a mobile banking application. The feature allows users to scan a QR code to automatically retrieve and populate PayID details, simplifying the payment process through Osko real-time payments on the Australian New Payments Platform (NPP).

## Project Overview
Currently, users are required to manually enter PayID details when transferring funds, which can lead to input errors and failed transactions. This project aims to improve accuracy, efficiency, and user experience by introducing a QR-based solution.

## Key Features
- QR code scanning for PayID details
- Automatic autofill of payee information
- Faster and more accurate transactions
- Improved user experience

## Technologies (Simulated)
- Mobile banking application environment
- QR code scanning functionality
- GitHub for version control and collaboration

## Purpose of Repository
This repository is used to simulate a collaborative development workflow using GitHub. It demonstrates branching, committing changes, pull requests, and merging processes as part of a team-based software development project.

---

## Security and Validation Feature (Added Contribution)

To improve the reliability and accuracy of transactions, a security and validation feature has been introduced. After scanning a PayID QR code, the system validates the extracted data before automatically filling in the payment details.

### How this feature works
- Checks whether the scanned QR code contains valid PayID data
- Verifies that the data format is correct
- Prevents incomplete or corrupted data from being used
- Ensures accurate autofill of payee information

### Importance of this feature
This feature is important because the application uses real-time payment systems such as Osko. Any incorrect input can result in failed or incorrect transactions. By validating QR data before autofill, the system enhances security, reduces user errors, and improves overall user trust.

---

## Author
Tanish
