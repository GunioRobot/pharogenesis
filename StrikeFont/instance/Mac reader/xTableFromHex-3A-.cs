xTableFromHex: file

	| strike num str wid |
	strike _ file.
	xTable _ (Array new: maxAscii + 3) atAllPut: 0.
	(minAscii + 1 to: maxAscii + 3) do:
		[:index | 
			num _ Number readFrom: (str _ strike next: 4) base: 16. 
			xTable at: index put: num].

	1 to: xTable size - 1 do: [:ind |
		wid _ (xTable at: ind+1) - (xTable at: ind).
		(wid < 0) | (wid > 40) ifTrue: [
			file close.
			self error: 'illegal character width']].
