initialize
	"HtmlEmbedded initialize"
	ExtensionList _ Dictionary new.
	#(
		('swf'	FlashPlayerMorph)
	) do:[:spec| ExtensionList at: spec first put: spec last].