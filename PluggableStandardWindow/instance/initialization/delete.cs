delete
	"Should be this way around since the window may not close
	for other reasons!"
	
	|m|
	m := model.
	super delete.
	closeWindowSelector ifNotNil:[m perform: closeWindowSelector]