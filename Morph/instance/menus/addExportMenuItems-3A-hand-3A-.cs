addExportMenuItems: aMenu hand: aHandMorph
	"Add export items to the menu"

	aMenu ifNotNil:
		[ | aSubMenu |
		aSubMenu _ MenuMorph new defaultTarget: self.
		aSubMenu add: 'BMP file' translated action: #exportAsBMP.
		aSubMenu add: 'GIF file' translated action: #exportAsGIF.
		aSubMenu add: 'JPEG file' translated action: #exportAsJPEG.
		aSubMenu add: 'PNG file' translated action: #exportAsPNG.
		aMenu add: 'export...' translated subMenu: aSubMenu]
