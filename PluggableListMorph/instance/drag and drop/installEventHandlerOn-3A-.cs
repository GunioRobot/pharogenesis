installEventHandlerOn: morphList

	| handler |

	handler _ EventHandler new.
	handler
		on: #mouseDown send: #mouseDown:onItem: to: self;
		on: #mouseUp send: #mouseUp:onItem: to: self.
	doubleClickSelector ifNotNil: [
		handler on: #doubleClick send: #doubleClick:onItem: to: self.
	].
	self dragEnabled
		ifTrue: [handler
				on: #startDrag
				send: #startDrag:onItem:
				to: self].
	self dropEnabled
		ifTrue: 
			[handler
				on: #mouseEnterDragging
				send: #mouseEnterDragging:onItem:
				to: self.
			handler
				on: #mouseLeaveDragging
				send: #mouseLeaveDragging:onItem:
				to: self].

	morphList do: [:m | m eventHandler: handler].
