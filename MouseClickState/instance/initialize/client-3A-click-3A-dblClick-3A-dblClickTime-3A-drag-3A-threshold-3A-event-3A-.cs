client: aMorph click: aClickSelector dblClick: aDblClickSelector dblClickTime: timeOut drag: aDragSelector threshold: aNumber event: firstClickEvent
	clickClient _ aMorph.
	clickSelector _ aClickSelector.
	dblClickSelector _ aDblClickSelector.
	dblClickTime _ timeOut.
	dragSelector _ aDragSelector.
	dragThreshold _ aNumber.
	firstClickDown _ firstClickEvent.
	firstClickTime _ firstClickEvent timeStamp.
	clickState _ #firstClickDown.