delete

	parentWrapper ifNil: [^Beeper beep].
	parentWrapper withoutListWrapper removeChild: item withoutListWrapper.
