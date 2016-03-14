
This is an ASCOM driver for the Opengear "IP Power 9258" power strip.

The driver supports up-to four independent boxes. They are configured in 
the Setup wizard, each of them having:
  - an IPv4 address
  - a user name and password
  - a name and description for each of the four power outlets

Each box can be independently enabled/disabled via a checkbox in the Setup wizard.
The configuration of a disabled box is remembered but accessing the switches on 
such a box causes exceptions.

The current version (6.0) passes the ASCOM Conformity tests for Switch devices.

For support please contact Arie Blumenzweig <blumzi@013.net>
