deleteIfPopUpFrom: item event: evt
	"Remove this menu from the screen if stayUp is not true, but only if the user did move the mouse since invoking me. This allows for click-move-click selection style."

	stayUp ifFalse: 
		[((self hasProperty: #stayUpOnce) or: 
			[(evt cursorPoint dist: originalEvent cursorPoint) < 2]) ifTrue:
				[self removeProperty: #stayUpOnce.
				^evt hand newMouseFocus: item "Do tracking and delete on next click"]].
	self deleteIfPopUp.
