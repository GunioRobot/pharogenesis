initialize
	"Initialize the receiver's graphics, name, and balloon-help"

	super initialize.
	self image: TrashPicOn;
		offImage: TrashPic;
		pressedImage: TrashPicOn.
	self setNameTo: 'Trash'.
	self setBalloonText:
'To remove an object, drop it on a trash can.'.
