extend
	| messageNodeMorph first |
	"replace this arg with a new message like (arg + 1)."

	"Later do evaluation of self to see what type and offer right selector"
	self deselect.
	messageNodeMorph _ (MessageSend receiver: 1 selector: #+ arguments: #(1))
								asTilesIn: Player.
	owner replaceSubmorph: self by: messageNodeMorph.
	first _ messageNodeMorph submorphs detect: [:mm | mm isSyntaxMorph].
	messageNodeMorph replaceSubmorph: first by: self.
	self acceptIfInScriptor.