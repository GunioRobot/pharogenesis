acceptValue: aValue

	"If target is a CardPlayer, and its costume is one of my owners, change target to its current CardPlayer"
	target class superclass == CardPlayer ifTrue: [
		(self hasOwner: target costume) ifTrue: [	
			self target: target costume player]].

	self updateContentsFrom: (self acceptValueFromTarget: aValue).
