delete

	parentWrapper ifNil: [^1 beep].
	parentWrapper withoutListWrapper removeChild: item withoutListWrapper.
