loadUpdates
	[Cursor wait showWhile: [
		squeakMap loadUpdates.
		self noteChanged ]
	] on: Error do: [:ex |
		self informException: ex msg: ('Error occurred when updating map:\', ex messageText, '\') withCRs]