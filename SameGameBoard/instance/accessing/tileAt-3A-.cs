tileAt: aPoint

	^ submorphs at: (aPoint x + (aPoint y * columns) + 1)