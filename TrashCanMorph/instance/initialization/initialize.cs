initialize

	super initialize.
	handsOverMe _ IdentitySet new.
	self image: TrashPicOn;
		offImage: TrashPic;
		pressedImage: TrashPicOn.
	self setNameTo: 'Trash'.
	self setProperty: #scriptingControl toValue: true.
	self setBalloonText:
'The Trash Can
To remove an object, drag it
over the Trash, and drop it,
and it will disappear.'.
