fillDict: dict with: nodeClass mapping: keys to: codeArray

	| codeStream key |
	codeStream _ ReadStream on: codeArray.
	keys do: 
		[:key | dict 
				at: key
				put:  (nodeClass new name: key key: key code: codeStream next)]