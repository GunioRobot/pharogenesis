show4

    " B3DDemoSurfaces new show4"

     | view |

  self createScene4.
  (view := B3DTutorialScenePresenterMorph new)
     source: self description: #descriptionScene4;
     scene: scene.
  view clearColor: (Color gray: 0.7).

  view rotateZ: 12.0.
  view openInSystemWindow