processMenuKey
	"The user typed a key on the keyboard. Perform the action of the button whose shortcut is that key, if any."

	| aView |
	aView _ view subViewContainingCharacter: sensor keyboard.
	aView ~~ nil ifTrue: [aView performAction].
