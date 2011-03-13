externalName

	parseNode ifNil: [^ 'Syntax -- (extra layer)'].
	^ self parseNode class printString