containsMethodAtPosition: aFilePosition
	"Answer whether the receiver contains the method logged at the given file position"

	"class: aClassSymbol" "(need class parameter to speed up?)"  "<- dew 9/6/2001"

	changeRecords values do:
		[:classChangeRecord |
		classChangeRecord methodChanges values do:
			[:methodChangeRecord | | changeType |
			changeType _ methodChangeRecord changeType.
			((changeType == #add or: [changeType == #change]) and:
				[methodChangeRecord currentMethod notNil and: [methodChangeRecord currentMethod filePosition = aFilePosition]])
					ifTrue: [^ true]]].
	^ false