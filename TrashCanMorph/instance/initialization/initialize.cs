initialize
	"Initialize the receiver's graphics, name, and balloon-help"

	super initialize.
	self image: TrashPicOn;
		offImage: TrashPic;
		pressedImage: TrashPicOn.
	self setNameTo: 'Trash' translated.
	self setBalloonText:
'To remove an object, drop it on any trash can. To view, and maybe retrieve, items that have been thrown away, double-click on any trash-can.  Things are retained in the trash-can if the "preserveTrash" preference is set, otherwise they are purged immediately' translated.
