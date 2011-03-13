colorPatch
	"Return a color patch button that lets the user choose a color and modifies the code"
	| msg cc patch ss |
	
	(self nodeClassIs: KeyWordNode) ifTrue: [
		msg _ self firstOwnerSuchThat: [:oo | 
			(oo isSyntaxMorph and: [oo nodeClassIs: MessageNode]) 
				ifTrue: [ss _ oo submorphs select: [:mm | mm isSyntaxMorph].
					ss size > 1 ifTrue: [ss second printString = 'r:g:b:']
							ifFalse: [false]]
				ifFalse: [false]]].
	"Later test for SelectorNode with a standard color name"
	(self nodeClassIs: VariableNode) ifTrue: [
		self printString = 'Color' ifTrue: [
			owner isSyntaxMorph ifTrue: [msg _ owner]]].

	msg ifNil: [^ nil].
	(cc _ msg try) class == Color ifFalse: [^ nil].
	patch _ RectangleMorph new color: cc; borderWidth: 1.
	patch on: #mouseDown send: #chooseColor to: msg.
	^ patch