buildPreferenceExportPane: exportPane onModel: aModel
	"1 Get the buttons"
	| buttons btn |
	buttons := OrderedCollection new.
	buttons _ #(

				
		#(nil #compact  'Salvage & compact DB' 	
				'Salvage any work done since the last database save & recover space used by old deleted messages.
(This may be a bit slow)')
	).
	
	buttons do:[:spec|				
		btn _ self buildButtonFromSpec: spec forModel: aModel.
		exportPane  addMorphBack: btn.
		exportPane addTransparentSpacerOfSize: 3 @ 0.
	].
