displayOnPort: port at: location
	port colorMap: (self colorMapForDepth: port destForm depth);
		copyForm: self to: location rule: Form over;
		colorMap: nil