configurationFrom: aCollection

	| spec | 
	spec := Array streamContents: [:s |
         s nextPut: #repository; nextPut: {self repository description}.
         aCollection do: [:ea | | pkg ver id |
             pkg := ea copyUpToLast: $- .
             ver := ea copyUpToLast: $. .
             id := UUID nilUUID asString.
             s nextPut: #dependency; nextPut: {pkg . ver . id}]].
    ^MCConfiguration fromArray: spec.