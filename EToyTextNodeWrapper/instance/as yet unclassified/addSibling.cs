addSibling

	parentWrapper ifNil: [^Beeper beep].
	parentWrapper addNewChildAfter: item.