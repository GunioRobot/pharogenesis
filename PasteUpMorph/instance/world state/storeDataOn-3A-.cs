storeDataOn: aDataStream
	"WorldMorphs only save certain fields when written to the disk.  Save only the world's submorphs, model, and stepList. See DataStream.typeIDFor:  "
	| cntInstVars instVars subs fldName toExclude |

	"Store normally, and it may or may not be installed as the World in the target system?"
	cntInstVars _ self class instSize.
	self class isVariable ifTrue: [self error: 'We are not a variable class'].
	instVars _ self class allInstVarNames.
	"remove the flaps"
	toExclude _ OrderedCollection new.
	Utilities globalFlapTabsIfAny do: [:aTab | 
		toExclude add: aTab.
		toExclude add: aTab referent].
	subs _ submorphs select: [:morph | (toExclude includes: morph) not].

	aDataStream
		beginInstance: self class
		size: cntInstVars "+ 0".
	1 to: cntInstVars do:
		[:i | (fldName _ instVars at: i) = 'owner' 
			ifTrue: [aDataStream nextPutWeak: owner]
					"owner only written if it is in our tree"
			ifFalse: [fldName = 'worldState' 
				ifTrue: [aDataStream nextPut: nil]	"worldState _ nil on disk"
				ifFalse: [fldName = 'submorphs' 
					ifTrue: [aDataStream nextPut: subs]
					ifFalse: [aDataStream nextPut: (self instVarAt: i)]]]].
	"No variable fields"