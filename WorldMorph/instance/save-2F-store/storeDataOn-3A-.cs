storeDataOn: aDataStream
	"WorldMorphs only save certain fields when written to the disk.  Save only the world's submorphs, model, and stepList. See DataStream.typeIDFor:  "
	| cntInstVars cntIndexedVars instVars data ind |

	cntInstVars _ self class instSize.
	cntIndexedVars _ self basicSize.
	instVars _ self class allInstVarNames.
	data _ Array new: instVars size.
	"Add any additional fields to write here"
	ind _ (instVars indexOf: 'model').
	(ind = 0) ifTrue: [self error: 'this method is out of date']
			ifFalse: [data at: ind put: model].
	ind _ (instVars indexOf: 'submorphs').
	(ind = 0) ifTrue: [self error: 'this method is out of date']
			ifFalse: [data at: ind put: submorphs].
	ind _ (instVars indexOf: 'stepList').
	(ind = 0) ifTrue: [self error: 'this method is out of date']
			ifFalse: [data at: ind put: stepList].

	aDataStream
		beginInstance: self class
		size: cntInstVars + cntIndexedVars.
	1 to: cntInstVars do:
		[:i | aDataStream nextPut: (data at: i)].
	1 to: cntIndexedVars do:
		[:i | aDataStream nextPut: (self basicAt: i)]