tileAt: aPoint

	^ submorphs at: (aPoint x + ((aPoint y - 1) * columns))