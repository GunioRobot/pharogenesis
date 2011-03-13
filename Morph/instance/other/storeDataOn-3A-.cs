storeDataOn: aDataStream
	"Let all Morphs be written out.  DataStream.typeIDFor: catches the ones that are outside our tree (most notably, the root's owner).  For now let everthing try to write out.  "
	| cntInstVars cntIndexedVars ti localInstVars got |

	"block my owner unless he is written out by someone else"
	got _ aDataStream references at: owner ifAbsent: [nil].
	got ifNotNil: ["My owner has already started to go out.  OK to point at him"
		^ super storeDataOn: aDataStream].
	cntInstVars _ self class instSize.
	cntIndexedVars _ self basicSize.
	localInstVars _ Morph instVarNames.
	ti _ 2.  
	((localInstVars at: ti) = 'owner') & (Morph superclass == Object) ifFalse:
			[self error: 'this method is out of date'].
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