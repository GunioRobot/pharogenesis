colorPatch
	"Return a color patch button that lets the user choose a color and modifies the code"
	| cc patch sel completeMsg |
	
	
	((self nodeClassIs: MessageNode) "or: [self nodeClassIs: SelectorNode]") ifFalse: [^ nil].
	(sel _ self selector) ifNil: [^ nil].
	(Color colorNames includes: sel) | (sel == #r:g:b:) ifFalse: [^ nil].
		"a standard color name"
	completeMsg _ self isNoun ifTrue: [self] 
				ifFalse: [owner isNoun ifTrue: [owner] ifFalse: [owner owner]].

	(cc _ completeMsg try) class == Color ifFalse: [^ nil].
	patch _ ColorTileMorph new colorSwatchColor: cc.
		"sends colorChangedForSubmorph: to the messageNode"
	patch color: Color transparent; borderWidth: 0.  patch submorphs last delete.
	^ patch