partsMenu
	"Show a menu listing all the parts of this message, and let the user save the chosen part to a file"

	| menu currMessage part |
	currentMsgID ifNil: [ ^self ].
	menu _ CustomMenu new.
	currMessage _ self currentMessage.
	currMessage atomicParts do: [:e | menu add: 'save ' , e printString action: e].
	part _ menu startUp.
	part ifNotNil: [part save]