bonk: glyphForm with: bonkForm
	"Bonking means to run through the glyphs clearing out black pixels
	between characters to prevent them from straying into an adjacent
	character as a result of, eg, bolding or italicizing"
	"Uses the bonkForm to erase at every character boundary in glyphs."
	| bb offset |
	offset _ bonkForm offset x.
	bb _ BitBlt current toForm: glyphForm.
	bb sourceForm: bonkForm; sourceRect: bonkForm boundingBox;
		combinationRule: Form erase; destY: 0.
	1 to: xTable size-1 do: [:i | bb destX: (xTable at: i) + offset; copyBits].
