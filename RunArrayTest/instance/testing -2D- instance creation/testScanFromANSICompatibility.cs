testScanFromANSICompatibility
	RunArray scanFrom: (ReadStream on: '()f1dNumber new;;').
	RunArray scanFrom: (ReadStream on: '()a1death;;').
	RunArray scanFrom: (ReadStream on: '()F1death;;').