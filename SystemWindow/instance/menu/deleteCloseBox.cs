deleteCloseBox
	closeBox ifNotNil:
		[closeBox delete.
		closeBox _ nil]