convertmmmmmmmmmmmmmmkkv0: varDict mmmmmmmmmmmmmmkkv0: smartRefStrm
	"These variables are automatically stored into the new instance ('mouseDownRecipient' 'mouseDownSelector' 'mouseStillDownRecipient' 'mouseStillDownSelector' 'mouseUpRecipient' 'mouseUpSelector' 'mouseEnterRecipient' 'mouseEnterSelector' 'mouseLeaveRecipient' 'mouseLeaveSelector' 'keyStrokeRecipient' 'keyStrokeSelector' 'valueParameter' ).
	This method is for additional changes. Use statements like (foo _ varDict at: 'foo')."

	"Be sure to to fill in ('mouseEnterDraggingRecipient' 'mouseEnterDraggingSelector' 'mouseLeaveDraggingRecipient' 'mouseLeaveDraggingSelector' ) and deal with the information in ('mouseEnterLadenRecipient' 'mouseEnterLadenSelector' 'mouseLeaveLadenRecipient' 'mouseLeaveLadenSelector' )"

mouseEnterDraggingRecipient _ varDict at: 'mouseEnterLadenRecipient'.
mouseEnterDraggingSelector _ varDict at: 'mouseEnterLadenSelector'.
mouseLeaveDraggingRecipient _ varDict at: 'mouseLeaveLadenRecipient'.
mouseLeaveDraggingSelector _ varDict at: 'mouseLeaveLadenSelector'.