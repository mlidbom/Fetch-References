﻿Fetches reference binaries from a repository structured something like this:

-Testing
--Web
---SomeLibrary
----trunk
----releases
-----1.0
-----1.1
---AnotherLibrary
----trunk
----releases
-----0.9


requires the configuration file: references.xml to be in the same folder as FetchReferences.exe.

Example references.xml:

<?xml version="1.0" encoding="utf-8" ?>
<references repositoryPath="\\ReferencesServer\Repository" localPath="external-libs">
  <reference name="SomeLibrary" version="1.1" />
  <reference name="AnotherLibrary" version="0.9" />
</references>

Running with this configuration file will create this structure

FetchReferences.exe
-external-libs
--SomeLibrary
--AnotherLibrary

The contents of SomeLibrary will be the contents of \\ReferencesServer\Repository\SomeLibrary\1.1
The contents of AnotherLibrary will be the contents of \\ReferencesServer\Repository\AnotherLibrary\0.9
