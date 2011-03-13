zapObsolete
"Command zapObsolete"
	"kill some obsolete stuff still retained by the CompiledMethods in change records"

	| before after histories lastCmd histCount lastCount |
	Smalltalk garbageCollect.
	before _ Command allInstances size.
	histories _ Association allInstances select: [ :each | 
		each key == #CommandHistory and: [
			(each value isKindOf: OrderedCollection) and: [
				each value isEmpty not and: [
					each value first isKindOf: Command]]]
	].
	histCount _ histories size.
	lastCmd _ Association allInstances select: [ :each | 
		each key == #LastCommand and: [each value isKindOf: Command]
	].
	lastCount _ lastCmd size.
	histories do: [ :each | each value: OrderedCollection new].
	lastCmd do: [ :each | each value: Command new].
	Smalltalk garbageCollect.
	Smalltalk garbageCollect.
	after _ Command allInstances size.
	Transcript show: {before. after. histCount. histories. lastCount. lastCmd} printString; cr; cr.
	