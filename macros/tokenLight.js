export const TORCH_ICON = 'icons/sundries/lights/torch-brown-lit.webp';

export const torchAnimation = {
    "intensity": 1,
    "speed": 1,
    "type": "torch"
};

export const mundaneLight = {
    "alpha": 0.1,
    "angle": 360,
    "animation": torchAnimation,
    "color": "#d98e26",
    "luminosity": 0.5
};

export const magicLight = {
    "alpha": 0.1,
    "angle": 360,
    "animation": { "type": "none" },
    "color": "#a6bbdd",
    "luminosity": 0.5
};
