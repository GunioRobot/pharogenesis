additionsToViewerCategoryObservation
	"Answer viewer additions for the 'observations' category"

	^#(
		observation
 
		(
			(slot colorUnder 'The color under the center of the object' Color readOnly Player getColorUnder unused  unused )
			(slot brightnessUnder 'The brightness under the center of the object' Number readOnly Player getBrightnessUnder unused unused)
			(slot luminanceUnder 'The luminance under the center of the object' Number readOnly Player getLuminanceUnder unused unused)
			(slot saturationUnder 'The saturation under the center of the object' Number readOnly Player getSaturationUnder unused unused)
		
		))
