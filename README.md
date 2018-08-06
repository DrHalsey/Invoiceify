Invoiceify
========
A small demo connecting to Xero's API to create Invoices. Hopefully this demonstrates some of my knowledge, as as mentioned I really thrive with debugging, fixes, and existing applications, but I'd like to get better at this type of stuff. 

* Overview
* Improvements
* Known Issues
* Along the Way


## Overview

There is a single view that calls the InvoiceController for getting and creating Invoices.

The Controller calls an Invoice Service, which then will make the API connection and/or create the audit data.

The API connection uses a Settings file to pull data from the config to make the API connection.


## Improvements

There are several items outside the known issues that if I had another few hours I'd focus on. These include:
* Getting some unit tests in place
* Allowing the user to specify some details for creating the invoice
* Possibly adding another project for the data to separate concerns a bit more. Since this was a small task, I kept everything in a single project but wouldn't normally do that for most things unless it was very small and had little chance of growing.
* Adding Interfaces


## Known Issues

As with any project, there's a few things bugs I'm aware of.

* The 'Create Invoice' functionality is not longer calling the correct method. I had it working, did some cleanup / refactor, and somehow broke it. Doh.
* The EF database isn't hooked up, despite my best efforts to debug it. The code has a method for create audit info but I'm adding a basic schema as part of the solution to the root as well.


## Along the Way

During this fun process I got to deal with random things, including a few hurdles. Some of these items included:

* Relative vs absolute pathing issues for the cert
* Data in the API not matching data on the Dashboard (invoices, contacts, still not sure why!) even after matching fields exactly as API Previewer
* Cached pages not showing latest changes, required to hard refresh to see latest changes sometimes
* jQuery crashing the page because of an error