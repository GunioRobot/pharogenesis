checkName: aFileName fixErrors: fixing
	"Check if the file name contains any invalid characters"
	| fName hasBadChars correctedName newChar|
	fName _ super checkName: aFileName fixErrors: fixing.
	correctedName _ String streamContents:[:s|
								fName do:[:c|
									(newChar _ LegalCharMap at: c asciiValue +1) ifNotNil:[s nextPut: newChar]]]. 
	hasBadChars _ fName ~= correctedName.
	(hasBadChars and:[fixing not]) ifTrue:[^self error:'Invalid file name'].
	hasBadChars ifFalse:[^ fName].
	^ correctedName