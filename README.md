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

For audit logging for the database, this was the part I was most unsure of. I included an improvement note below and a very basic sample schema with a single tab for when Invoices are created.


## Improvements

There are several items outside the known issues that if I had another few hours I'd focus on. These include:
* Lightweight ORM: I'd like to implement Dapper or SQLLite if I couldn't get EF working
* Getting some unit tests in place
* Allowing the user to specify some details for creating the invoice
* Possibly adding another project for the data to separate concerns a bit more. Since this was a small task, I kept everything in a single project but wouldn't normally do that for most things unless it was very small and had little chance of growing.
* Adding Interfaces
* Understand logging requirements a little more clearly. Should the whole payload be captured? If using the wrapper, how to best capture response? Different tables for each object type? Etc. Numerous online searches also did not seem to return a commonly accepted pattern.
* (Low priority) For the view, refresh the data immediately after a new invoice is created without having to press the refresh button


## Known Issues

As with any project, not everything goes the way you want. Here are the biggest ones I'm currently aware of.

* The EF database isn't hooked up, despite my best efforts to debug it. The code has a method for create audit info but I'm adding a basic schema as part of the solution to the root as well.


## Along the Way

During this fun process I got to deal with random things, including a few hurdles. Some of these items included:

* Relative vs absolute pathing issues for the cert
* Data in the API not matching data on the Dashboard (invoices, contacts, still not sure why!) even after matching fields exactly as API Previewer
* Cached pages not showing latest changes, required to hard refresh to see latest changes sometimes
* jQuery crashing the page because of an unknown error, possibly versioning issues but still unclear
* SQL Server browser was Disabled and was preventing part of EF from working (or that was part of it)