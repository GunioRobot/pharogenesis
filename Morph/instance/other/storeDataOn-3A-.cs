storeDataOn: aDataStream
	"Let all Morphs be written out.  DataStream.typeIDFor: catches the ones that are outside our tree (most notably, the root's owner).  For now let everthing try to write out.  "
	| cntInstVars cntIndexedVars instVars ti got |

	true ifTrue: [^ super storeDataOn: aDataStream].

	"keep this code in case we need to filter fields later"
	owner ifNil: [^ super storeDataOn: aDataStream].
	got _ aDataStream references at: owner ifAbsent: [nil].
	got ifNotNil: ["My owner has already started to go out.  I am not top"
		^ super storeDataOn: aDataStream].
	"block my owner"
	cntInstVars _ self class instSize.
	cntIndexedVars _ self basicSize.
	instVars _ self class allInstVarNames.
	ti _ (instVars indexOf: 'owner').
	(ti = 0) ifTrue: [self error: 'this method is out of date'].
	aDataStream
		beginInstance: self class
		size: cntInstVars + cntIndexedVars.
	1 to: ti-1 do:
		[:i | aDataStream nextPut: (self instVarAt: i)].
	aDataStream nextPut: nil.	"owner"
	ti+1 to: cntInstVars do:
		[:i | aDataStream nextPut: (self instVarAt: i)].
	1 to: cntIndexedVars do:
		[:i | aDataStream nextPut: (self basicAt: i)]