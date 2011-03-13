changeModelSelection: anInteger 
	Cursor execute showWhile:
		[model toggleContextStackIndex: anInteger]