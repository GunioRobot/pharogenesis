createTextBars
	"title"
	titleMorph _ StringMorph new contents: ' ATOMIC 1.2 ';
				 font: Preferences windowTitleFont emphasis: 3.
	titleMorph position: bounds origin x @ bounds corner y + currentMap borderSpace.
	titleMorph color: Color blue twiceDarker.
	self addMorph: titleMorph.
	bounds _ bounds extendBy: 0 @ titleMorph bounds height + currentMap borderSpace.
	"information"
	infoMorph _ StringMorph new contents: self levelMessage.
	infoMorph position: bounds origin x @ bounds corner y + currentMap borderSpace.
	infoMorph color: Color gray twiceDarker.
	self addMorph: infoMorph.
	bounds _ bounds extendBy: 0 @ infoMorph bounds height + currentMap borderSpace.
	"points"
	pointsMorph _ StringMorph new contents: ''.
	pointsMorph position: bounds origin x @ bounds corner y + currentMap borderSpace.
	pointsMorph color: Color gray twiceDarker.
	self addMorph: pointsMorph.
	bounds _ bounds extendBy: 0 @ pointsMorph bounds height + currentMap borderSpace