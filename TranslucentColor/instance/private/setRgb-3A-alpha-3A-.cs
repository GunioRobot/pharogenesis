setRgb: rgbValue alpha: alphaValue
	rgb _ rgbValue.
	alpha _ (255.0*alphaValue) asInteger min: 255 max: 0