addExtraSpace: aPoint
	extraSpace 
		ifNil:[extraSpace _ aPoint]
		ifNotNil:[extraSpace _ extraSpace + aPoint]