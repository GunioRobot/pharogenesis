partsMenu
	| menu currMessage part |
	menu _ CustomMenu new.
	currMessage _ self currentMessage.
	currMessage body atomicParts do: [:e | menu add: 'save ' , e printString action: e].
	part _ menu startUp.
	part ifNotNil: [part save]