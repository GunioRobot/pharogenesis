testIntegerHex
| result |
result _ 15 asInteger hex.
self assert: result = '0F'.
result _ 0 asInteger hex.
self assert: result = '00'.
result _ 255 asInteger hex.
self assert: result = 'FF'.
result _ 90 asInteger hex.
self assert: result = '5A'.

