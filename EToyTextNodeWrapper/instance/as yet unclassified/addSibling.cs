addSibling

	parentWrapper ifNil: [^1 beep].
	parentWrapper addNewChildAfter: item.