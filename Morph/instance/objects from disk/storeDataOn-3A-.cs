storeDataOn: aDataStream
	"Let all Morphs be written out.  All owners are weak references.  They only go out if the owner is in the tree being written."
	| cntInstVars cntIndexedVars ti localInstVars |

	"block my owner unless he is written out by someone else"
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
	aDataStream nextPutWeak: owner.	"owner only written if in our tree"
	ti+1 to: cntInstVars do:
		[:i | aDataStream nextPut: (self instVarAt: i)].
	1 to: cntIndexedVars do:
		[:i | aDataStream nextPut: (self basicAt: i)]