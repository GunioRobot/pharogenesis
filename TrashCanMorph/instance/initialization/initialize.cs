initialize

	super initialize.
	self image: TrashPicOn;
		offImage: TrashPic;
		pressedImage: TrashPicOn.
	self setNameTo: 'Trash'.
	self setBalloonText:
'To remove an object, drop it on this trash can.'.
