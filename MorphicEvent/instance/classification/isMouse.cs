isMouse

	^ (type == #mouseMove) | (type == #mouseDown) | (type == #mouseUp)